# WSolver
WSolver solves non-linear equations using pricise calculation methods. Built using Windows Forms.
The whole process: 
1. User inputs equation
2. This formula is parsed and transformed into function f(x)
3. Equation f(x) = 0 is solved using various ways, listed further

### Root-finding methods:
* Bisection (dichotomy)
  * [Searching roots on one big segment](WSolver/Dichotomy.cs)
  * [Searching roots on segment divided into many little parts](WSolver/SmallSegments.cs) 
* [Secant Method](WSolver/Secant.cs)

