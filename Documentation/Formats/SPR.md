# SPR - `*.spr`

The SPR (Spray) file format is Pangya's animation scripting format, used to define particle based animations which then are used in `.seq` files to create animation loops.

## File Structure

SPR files are relatively simply structured, containing a line-spanning command. Some quirk about their syntax, commented lines start with `;`, so those shouldn't be interpreted.

### Sprite Commands

Calls to commands follow this structure:

```
[command] = [comma-separated arguments, parenthesis-wrapped lists]
```

#### Texture Source

**Command:** `Source`

**Arguments:**

- File Name
- Sprite Width
- Sprite Height
- _(optional)_ Billboard On/Off

#### Puppet Source

**Command:** `Source`

**Arguments:**

- File Name (prefixed with `*pet`)
- Lighting _(petlight)_

#### Blend Mode

**Command:** `Blend`

**Arguments:**

- Blend Mode, one of:
  - `Normal`
  - `Add`
  - `Multiply`
  - `InvMultiply`
- Tail Blend Mode, one of:
  - `Normal`
  - `Add`
  - `Multiply`
  - `InvMultiply`

#### Lighting

**Command:** `Lighting`

**Arguments:**

- Lighting Mode, one of or none:
  - `Off`
  - `Diffuse`
  - `Ambient1`
  - `Ambient2`

#### Generation Position

**Command:** `GenPos`

**Arguments:**

- Minimum AABB (Axis-aligned bounding box)
  - `x`
  - `y`
  - `z`
- Maximum AABB
  - `x`
  - `y`
  - `z`

#### Initial Size

**Command:** `Init_Size`

**Arguments:**

- Multiples (between 0 and 1)
  - Minimal Size
  - Maximum Size

#### Add Size

**Command:** `Add_Size`

**Arguments:**

- Percentiles
  - Start Time
  - Start Size
- Percentiles
  - End Time
  - End Size

#### Initial Frame

**Command:** `Init_Frame`

**Arguments:**

- Integer values
  - Minimal Frame
  - Maximum Frame

#### Frame Transition

**Command:** `Add_Frame`

**Arguments:**

- Percentiles
  - Start Time
  - End Time
- Integer values
  - Start Frame
  - End Frame
  - Transition Time (ms/frames)

#### Add Generation

**Command:** `Add_Generation`

**Arguments:**

- Integer values
  - Start Frame
  - End Frame
- Number of items to generate
- Angle of Cone (deg/rad)

#### Lifetime

**Command:** `LifeTime`

**Arguments:**

- Float values
  - Minimum lifetime (ms/frames)
  - Maximum lifetime (ms/frames)

#### Fade Color

**Command:** `Add_Fade`

**Arguments:**

- Start values
  - Start Time (Percentile)
  - Start Color (ARGB_255)
- End values
  - End Time (Percentile)
  - End Color (ARGB_255)

#### Initial Velocity

**Command:** `Init_Velocity`

**Arguments:**

- Minimum Velocity Direction
  - `x`
  - `y`
  - `z`
- Maximum Velocity Direction
  - `x`
  - `y`
  - `z`

#### Add Velocity

**Command:** `Add_Velocity`

**Arguments:**

- Start values
  - Start Time (ms/frames)
  - Start Velocity
- End values
  - End Time (ms/frames)
  - End Velocity

#### Tail

**Command:** `Tail`

**Arguments:**

- Length
- Generation Interval (ms/frames)
- End Color (ARGB_255)
- Texture File Name
- Width
- Status (_monolith_)
- Facing Camera (_cameraside_)

#### Initial Angle

**Command:** `Init_Angle`

**Arguments:**

- Minimum Angles (deg/rad)
  - `x`
  - `y`
  - `z`
- Maximum Angles (deg/rad)
  - `x`
  - `y`
  - `z`

#### Initial Rotation

**Command:** `Init_Rotation`

**Arguments:**

- Minimum Angular Velocity (deg/rad)
  - `x`
  - `y`
  - `z`
- Maximum Angular Velocity (deg/rad)
  - `x`
  - `y`
  - `z`

#### Add Rotation

**Command:** `Add_Rotation`

**Arguments:**

- Start values
  - Start Time (Percentile)
  - Start Angular Velocity (Percentile)
- End values
  - End Time (Percentile)
  - End Angular Velocity (Percentile)

#### Air Friction

**Command:** `Friction`

**Arguments:**

- Friction (Float)

#### Ground Friction

**Command:** `GroundFriction`

**Arguments:**

- Friction (Float)

#### Gravity

**Command:** `Gravity`

**Arguments:**

- Gravity Direction
  - `x`
  - `y`
  - `z`

#### Add Gravity Point

**Command:** `Add_GravityPoint`

**Arguments:**

- Center Position
  - `x`
  - `y`
  - `z`
- Intensity
- Barrier Range
- Out-of-Range Intensity

#### Ground

**Command:** `Ground`

**Arguments:**

- Height
- Elasticity (Percentile)
- Collision Radius

#### Add Quake

**Command:** `Add_Quake`

**Arguments:**

- Center Position
  - `x`
  - `y`
  - `z`
- Start values
  - Start Time (ms/frames)
  - Start Intensity
    - `x`
    - `y`
    - `z`
- End values
  - End Time (ms/frames)
  - End Intensity
    - `x`
    - `y`
    - `z`
- Time Interval (ms/frames)

#### Add Flash

**Command:** `Add_Flash`

**Arguments:**

- Start Time (ms/frames)
- Maximum Time (ms/frames)
- End Time (ms/frames)

#### Camera Offset

**Command:** `CamOffset`

**Arguments:**

- Offset to Camera (Float)

#### Core Generation Region

**Command:** `Vol_Core`

**Arguments:**

- Positional values
  - Horizontal Scale
  - Vertical Scale

#### Core Opacity

**Command:** `Vol_Max_Opacity`

**Arguments:**

- Opacity (Float)

#### Distance Limit

**Command:** `Dist_Limit`

**Arguments:**

- Positional values
  - `x`
  - `y`

#### Add Bubble Motion

**Command:** `Add_Bubble`

**Arguments:**

- Bubble motion values
  - Front/Back Amplitude
  - Frequency/second
- Bubble motion values
  - Bottom Amplitude
  - Frequency/second
- Bubble motion values
  - Left/Right Amplitude
  - Frequency/second

#### Attacher Orientation

**Command:** `Ext_Orientation`

**Arguments:**

- `x` (0 or 1)
- `y` (0 or 1)
- `z` (0 or 1)

#### Additional Wind

**Command:** `Add_Wind`

**Arguments:**

- Float values
  - Minimum Rate
  - Maximum Rate

#### External Wind Simulation

**Command:** `Ext_Wind`

**Arguments:**

- Positional values
  - `x`
  - `y`
  - `z`

#### Bounding Box Appearance

**Command:** `IsSphere`

**Arguments:**

- Integer (0: Box, 1: Sphere)

#### Regenerate At Same Position

**Command:** `RegenAtSamePos`

**Arguments:**

- Integer boolean representation
