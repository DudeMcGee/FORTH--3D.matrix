# FORTH--3D.matrix
A prototype of a 3D matrix builder written as a FORTH word
## Details
A detailed description can be found in the PDF file.
# An Example of How NOT to Write FORTH Code
My code is a very good example, how not to write FORTH. The program is monolithic instead of being built with many small bricks and one-liners.
The degree of difficulty and complexity is simply too high: You should avoid this.
So, if you write code like I did here, most probably you're doing something wrong.
## Restrictions, Bugs etc.
When a matrix is defined, three parameters have to be put on the stack: a, b and c. They are the number of cells per dimension, x, y and z. The code can only work with a, b and c > 0. If one parameter equals zero, any write command containing a zero in the cell address will fail. This means, a 3D matrix is only a 3D matrix in the context of this code when it has 3 real dimensions, each at least 1 in size.
