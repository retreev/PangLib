# SPR - `*.spr`

The SPR (Spray) file format is Pangya's animation scripting format, used to define particle based animations which then are used in `.seq` files to create animation loops.

## File Structure

SPR files are relatively simply structured, containing a line-spanning command. Some quirk about their syntax, commented lines start with `;`, so those shouldn't be interpreted.

### Sprite Commands

Calls to commands follow this structure:

```
[command] = [comma-separated arguments, parenthesis-wrapped lists]
```

You can find a reference sheet with all currently known commands in `Documentation/Formats/SPR/Reference.md`
