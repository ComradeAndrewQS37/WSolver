# WSolver
WSolver solves non-linear equations using precise calculation methods. Built using Windows Forms.
The whole process: 
1. Input equation in special field
2. The formulae is parsed and transformed into function $f(x)$
3. Equation $f(x) = 0$ is solved using various methods (may be chosen by user)

## Root-finding methods:
* Bisection (dichotomy), each segment is divided into two parts, and part with solution is chosen to continue the process that ends when segment length corresponds to necessary precision
  * [Searching roots on one big segment](WSolver/Dichotomy.cs)
  * [Searching roots on segment divided into many little parts](WSolver/SmallSegments.cs) 
* [Newton method](WSolver/Newton.cs), the idea is to start with an initial guess which is reasonably close to the true root (solution) and then to use the tangent line to obtain another x-intercept that is even better than our initial guess or starting point
* [Secant method](WSolver/Chords.cs), uses a series of secant lines to better approximate the root
* [Fixed point method](WSolver/FixedPoint.cs), the equation $f(x) = 0$ can be converted algebraically into the form $x = g(x)$ and then the iterative scheme with the recursive relation $x_{i+1}=g(x_i)$ with some initial guess $x_0$ is used to approximate the solution
