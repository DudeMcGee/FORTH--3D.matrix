: 3d.matrix
  create
    ( x y z )
    dup   \ x y z z
    1 < if ." no values less than 1" abort then dup
    ,     \ x y z
    swap  \ x z y
    dup   \ x z y y
    1 < if ." no values less than 1" abort then dup
    ,     \ x z y
    rot   \ z y x
    dup   \ z y x x
    1 < if ." no values less than 1" abort then dup
    ,     \ z y x
    *     \ z yx
    *     \ zyx  That's the amount of payload cells
    3 +   \ ALLOT three cells more!
    4     \ Cell size! ALLOT works with bytes!
    *     \ So we have to multiply it!
    allot
  does>
    ( a b c pfa )
    \ Stack check
    depth 1 =  \ no parameters, just <matrix> = pfa
    if
      cr                    \ .pfa.
      dup                   \ .pfa. .pfa.
      ."      PFA = " . cr  \ .pfa.
      dup                   \ .pfa. .pfa.
      @                     \ .pfa. pfa
      ."    c (z) = " . cr  \ .pfa.
      dup
      1 cells +
      @
      ."    b (y) = " . cr
      dup
      2 cells +
      @
      ."    a (x) = " . cr
      3 cells +
      ." 1st cell = " . cr
      exit
    then
    depth 4 <
    if
      ." not enough data"
      exit
    then
    \ START:
    swap        \ a b .pfa. c
    2swap       \ .pfa. c a b
    rot         \ .pfa. a b c

    \ Check limits:

    dup         \ .pfa. a b c c

    4 pick @    \ .pfa. a b c c c.limit
    \ 1 -
    \ cr ." c : " prstln
    >= if ." c off limits" abort then

    swap        \ .pfa. a c b
    dup         \ .pfa. a c b b
    4 pick
    1 cells + @ \ .pfa. a c b b b.limit
    \ 1 -
    \ cr ." b : " prstln
    >= if ." b off limits" abort then

    rot         \ .pfa. c b a
    dup         \ .pfa. c b a a
    4 pick
    2 cells + @ \ .pfa. c b a a a.limit
    \ 1 -
    \ cr ." a : " prstln
    >= if ." a off limits" abort then

    \ End of check sequence!

                \ .pfa. c b a
    swap        \ .pfa. c a b
    rot         \ .pfa. a b c

    \ target formula: azy + bz + c

                \ .pfa. a b c
    rot         \ .pfa. b c a
    dup         \ .pfa. b c a a
    4 pick      \ Fetch z
    @           \ .pfa. b c a a z
    *           \ .pfa. b c a az
    4 pick      \ Fetch y
    1 cells + @ \ .pfa. b c a az y
    *           \ .pfa. b c a azy
    swap        \ .pfa. b c azy a
    drop        \ .pfa. b c azy
    rot         \ .pfa. c azy b
    3 pick      \ Fetch z
    @           \ .pfa. c azy b z
    *           \ .pfa. c azy bz
    +           \ .pfa. c azy+bz
    +           \ .pfa. c+azy+bz
    cells
    +           \ sum up
    3 cells +   \ Find first payload cell
;
