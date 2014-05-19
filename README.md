# OpenECC Disclaimer

OpenECC was built as part of a bachelors project to showcase a possible architecture of an ECC library and
show implementations of the constructs used in ECC. The library is not, in its current form, fit for use in
production. Real-world applicability was not a goal of the project, and as such certain concerns were left out:

- None of the curves supported in OpenECC live up to [Bernstein and Lange's requirements for safe curves](http://safecurves.cr.yp.to).
- Timing attacks have not been considered and it is very possible that the implementation unwittingly leaks information about the computations performed.