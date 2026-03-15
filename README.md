# gnc - <ins>g</ins>eneralized <ins>N</ins>aibbe <ins>c</ins>ipher
.NET implementation of the cipher described in [this](https://www.tandfonline.com/doi/full/10.1080/01611194.2025.2566408) paper by Michael A. Greshko. This solution was initially intended primarily for learning EF Core, but i now intend to make a visualization tool which allows you to see the steps taken by the cipher and to modify how it works.

## Details
Because i do not have the material constraints imposed in the paper (namely, i am writing a program, rather than limiting myself to materials available to 14th-century Europeans), the actual randomization is currently done directly by a `Random` class, though i intend to add the option to visualize the use of dice and cards in the future. i also simplified the respacing step slightly, by assigning the Unigram, Prefix, and Suffix states directly to characters rather than grouping them together, which allows some code to be simplified.

## Credits
- csv files `alpha`, `beta_1`, `beta_2`, `beta_3`, `gamma_1`, and `gamma_2` adapted from the corresponding tables α, β<sub>1</sub>, β<sub>2</sub>, β<sub>3</sub>, γ<sub>1</sub>, and γ<sub>2</sub> given in the [paper](https://www.tandfonline.com/doi/full/10.1080/01611194.2025.2566408);
- i only discovered the paper from the [Voynich Manuscript Day 2025 presentation](https://www.youtube.com/watch?v=ByARtG-GUPo&t=1h32m35s) also made by Greshko;
- Voynich font is available [here](https://www.kreativekorp.com/software/fonts/voynich/) from KreativeKorp.