# TALK - `*.talk`

The TALK file format is used by Pangya to define what a caddie will say/do in certain situations.

## File Structure

The file structure of TALK files is really simple. Every line contains a definition of an event, a numeric value (like in MOTs probably a behaviour/motion), and a text.

```
[event]:[value]:[text]
```

Example (from `cadie.talk`):

```
turbulence5:4:This is some serious turbulence.
```

Cadie will say _"This is some serious turbulence"_ on a course with 9m wind.
