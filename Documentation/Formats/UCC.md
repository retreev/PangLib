# UCC - `*.jpg`

The UCC (Self-Design) file format contains Pangya designs created by players for players. These files are archives which contain binary data for each of the design parts.

## File Structure

The base UCC image file (usually a JPEG) is not actually an image, but a zip archive (discernible by the `PK` header present).

Unpacking that archive yields 3 files:

- `front`: front face of the design
- `back`: back face of the design
- `icon`: shop icon for the design

### `front` / `back`

The structure of the data inside is relatively simple. It's just binary data, where each byte is a color value.

The order of the byte value in correspondence to RGB color values is `BGR` continuously until the end.

### `icon`

Icons follow the same structure, but they include transparency, meaning a fourth value, `alpha`.

So, the order of the byte values is `BGRA` for icons!
