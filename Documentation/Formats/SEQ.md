# SEQ - `*.seq`

The SEQ (Sequence) file format is animation sequencing/timing format, used to load Sprays at different times and positions, apply additional effects and loop them if required.

## File Structure

SEQ files follow the same structure as SPR files, using a full line for a command. Additional to the general scripting used across SPR and SEQ files,
SEQ files offer the ability to create named jump labels (e.g. `loop_a:`).

Inside the named loops, there are also timing definitions, written like labels, just with numbers (e.g. `0000:`), the 4-number style let's us assume that the time unit is either milliseconds or frames.

If there is a command that only starts with a colon instead of a timing definition, it's probably a timeless function, related to the whole sequence, rather than a parent call or something else in the file, we just give it a timing value of `null`.

## Sequence Commands

Calls to commands follow this structure:

```
[time]: [command] = [comma-separated arguments, parenthesis-wrapped lists]
```

You can find a reference sheet with all currently known commands in `Documentation/Formats/SEQ/Reference.md`
