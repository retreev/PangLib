# Spray (SPR) - Command Reference

## Table of Contents

- [Commands](#commands)
  - [`Source`](#source)
  - [`Blend`](#blend)
  - [`Lighting`](#lighting)
  - [`GenPos`](#genpos)
  - [`Init_Size`](#init_size)
  - [`Add_Size`](#add_size)
  - [`Init_Frame`](#init_frame)
  - [`Add_Frame`](#add_frame)
  - [`Add_Generation`](#add_generation)
  - [`LifeTime`](#lifetime)
  - [`Add_Fade`](#add_fade)
  - [`Init_Velocity`](#init_velocity)
  - [`Add_Velocity`](#add_velocity)
  - [`Tail`](#tail)
  - [`Init_Angle`](#init_angle)
  - [`Init_Rotation`](#init_rotation)
  - [`Add_Rotation`](#add_rotation)
  - [`Friction`](#friction)
  - [`GroundFriction`](#groundfriction)
  - [`Gravity`](#gravity)
  - [`Add_GravityPoint`](#add_gravitypoint)
  - [`Ground`](#ground)
  - [`Add_Quake`](#add_quake)
  - [`Add_Flash`](#add_flash)
  - [`CamOffset`](#camoffset)
  - [`Vol_Core`](#vol_core)
  - [`Vol_Max_Opacity`](#vol_max_opacity)
  - [`Dist_Limit`](#dist_limit)
  - [`Add_Bubble`](#add_bubble)
  - [`Ext_Orientation`](#ext_orientation)
  - [`Add_Wind`](#add_wind)
  - [`Ext_Wind`](#ext_wind)
  - [`IsSphere`](#issphere)
  - [`RegenAtSamePos`](#regenatsamepos)

## Commands

### `Source`

**Texture Source**

```
Source = [Explode.jpg, 32, 32
```

**Arguments:**

- File Name
- Sprite Width
- Sprite Height
- _(optional)_ Billboard On/Off

**Puppet Source**

```
Source = *pet gp_blackhole-purple02.pet, petlight
```

**Arguments:**

- File Name (prefixed with `*pet`)
- Lighting _(petlight)_

### `Blend`

```
Blend = Add, Add
```

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

### `Lighting`

```
Lighting = Off
```

**Arguments:**

- Lighting Mode, one of or none:
  - `Off`
  - `Diffuse`
  - `Ambient1`
  - `Ambient2`

### `GenPos`

```
GenPos = (0, 0, 0), (0, 0, 0)
```

**Arguments:**

- Minimum AABB (Axis-aligned bounding box)
  - `x`
  - `y`
  - `z`
- Maximum AABB
  - `x`
  - `y`
  - `z`

### `Init_Size`

```
Init_Size = (1.45, 1.45), 1
```

**Arguments:**

- Multiples (between 0 and 1)
  - Minimal Size
  - Maximum Size
  - Ratio

### `Add_Size`

```
Add_Size = (0 %, 90 %), (100 %, 150 %)
```

**Arguments:**

- Percentiles
  - Start Time
  - Start Size
- Percentiles
  - End Time
  - End Size

### `Init_Frame`

```
Init_Frame = (0, 2)
```

**Arguments:**

- Integer values
  - Minimal Frame
  - Maximum Frame

### `Add_Frame`

```
Add_Frame = (0%, 100%), (0, 15, 1f)
```

**Arguments:**

- Percentiles
  - Start Time
  - End Time
- Integer values
  - Start Frame
  - End Frame
  - Transition Time (ms/frames)

### `Add_Generation`

```
Add_Generation = (0, 100), 30, 30d
```

**Arguments:**

- Integer values
  - Start Frame
  - End Frame
- Number of items to generate
- Angle of Cone (deg/rad)

### `LifeTime`

```
LifeTime = (40f, 60f)
```

**Arguments:**

- Float values
  - Minimum lifetime (ms/frames)
  - Maximum lifetime (ms/frames)

### `Add_Fade`

```
Add_Fade = (0 %, (255, 255, 100, 100)), (100 %, (255, 255, 100, 100))
```

**Arguments:**

- Start values
  - Start Time (Percentile)
  - Start Color (ARGB_255)
- End values
  - End Time (Percentile)
  - End Color (ARGB_255)

### `Init_Velocity`

```
Init_Velocity = (0, 0.2, 0), (0, 0.5, 0)
```

**Arguments:**

- Minimum Velocity Direction
  - `x`
  - `y`
  - `z`
- Maximum Velocity Direction
  - `x`
  - `y`
  - `z`

### `Add_Velocity`

```
Add_Velocity = (0, 100 %), (5000, 0 %)
```

**Arguments:**

- Start values
  - Start Time (ms/frames)
  - Start Velocity
- End values
  - End Time (ms/frames)
  - End Velocity

### `Tail`

```
Tail = 10, 3f, (255, 0, 0, 0), ~ball_straight.jpg, 90, monolith, cameraside
```

**Arguments:**

- Length
- Generation Interval (ms/frames)
- End Color (ARGB_255)
- Texture File Name
- Width
- Status (_monolith_)
- Facing Camera (_cameraside_)

### `Init_Angle`

```
Init_Angle = (0d, 0d, 0d), (360d, 360d, 360d)
```

**Arguments:**

- Minimum Angles (deg/rad)
  - `x`
  - `y`
  - `z`
- Maximum Angles (deg/rad)
  - `x`
  - `y`
  - `z`

### `Init_Rotation`

```
Init_Rotation = (-10d, -10d, -10d), (10d, 10d, 10d)
```

**Arguments:**

- Minimum Angular Velocity (deg/rad)
  - `x`
  - `y`
  - `z`
- Maximum Angular Velocity (deg/rad)
  - `x`
  - `y`
  - `z`

### `Add_Rotation`

```
Add_Rotation = (0%, 100%), (100%, 100%)
```

**Arguments:**

- Start values
  - Start Time (Percentile)
  - Start Angular Velocity (Percentile)
- End values
  - End Time (Percentile)
  - End Angular Velocity (Percentile)

### `Friction`

```
Friction = 0.003
```

**Arguments:**

- Friction (Float)

### `GroundFriction`

```
GroundFriction = 0.1
```

**Arguments:**

- Friction (Float)

### `Gravity`

```
Gravity = (0, -0.01, 0)
```

**Arguments:**

- Gravity Direction
  - `x`
  - `y`
  - `z`

### `Add_GravityPoint`

```
Add_GravityPoint = (0, 0, 0), 0, 0, 0.03
```

**Arguments:**

- Center Position
  - `x`
  - `y`
  - `z`
- Intensity
- Barrier Range
- Out-of-Range Intensity

### `Ground`

```
Ground = 0, 1%, 0
```

**Arguments:**

- Height
- Elasticity (Percentile)
- Collision Radius

### `Add_Quake`

```
Add_Quake = (0, 0, 0), (1000, (0, 0, 0)), (2000, (0, 0, 0))
```

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

### `Add_Flash`

```
Add_Flash = 0, 5, 10
```

**Arguments:**

- Start Time (ms/frames)
- Maximum Time (ms/frames)
- End Time (ms/frames)

### `CamOffset`

```
CamOffset = 0.1
```

**Arguments:**

- Offset to Camera (Float)

### `Vol_Core`

```
Vol_Core = (0.85, 0.8)
```

**Arguments:**

- Positional values
  - Horizontal Scale
  - Vertical Scale

### `Vol_Max_Opacity`

```
Vol_Max_Opacity = 0.5
```

**Arguments:**

- Opacity (Float)

### `Dist_Limit`

```
Dist_Limit = 300, 400
```

**Arguments:**

- Positional values
  - `x`
  - `y`

### `Add_Bubble`

```
Add_Bubble = (0, 0), (0.003, 2.2), (0.003, 2)
```

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

### `Ext_Orientation`

```
Ext_Orientation = 1, 1, 1
```

**Arguments:**

- `x` (0 or 1)
- `y` (0 or 1)
- `z` (0 or 1)

### `Add_Wind`

```
Add_Wind = (0.03, 0.05)
```

**Arguments:**

- Float values
  - Minimum Rate
  - Maximum Rate

### `Ext_Wind`

```
Ext_Wind = (1, 0, 0)
```

**Arguments:**

- Positional values
  - `x`
  - `y`
  - `z`

### `IsSphere`

```
IsSphere = 1
```

**Arguments:**

- Integer (0: Box, 1: Sphere)

### `RegenAtSamePos`

```
RegenAtSamePos = 1
```

**Arguments:**

- Integer boolean representation
