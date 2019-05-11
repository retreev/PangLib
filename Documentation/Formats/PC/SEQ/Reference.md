# Sequence (SEQ) - Command Reference

## Table of Contents

- [Commands](#commands)
  - [`Spray`](#spray)
  - [`Add_Spawn`](#add_spawn)
  - [`Add_Rotation`](#add_rotation)
  - [`Add_NRotation`](#add_nrotation)
  - [`Add_Revolution`](#add_revolution)
  - [`Add_PRevolution`](#add_prevolution)
  - [`AttachedToParent`](#attachedtoparent)
  - [`stop`](#stop)
  - [`goto`](#goto)

## Commands

### `Spray`

```
0000: Spray = xmas_roi.spr, (0, 0, 0), (0, 0, 0.), strongbond
```

#### Arguments:

- File Name
- Positional Values
  - `x`
  - `y`
  - `z`
- Speed values
  - `x`
  - `y`
  - `z`
- Binding type (_strongbond_)

### `Add_Spawn`

```
:Add_spawn = airnight3_wave.spr, attached, (interval, 500, 20)
:Add_spawn = airnight3_wave.spr, attached, (onground)
:Add_spawn = airnight3_wave.spr, attached, (ondeath)
:Add_spawn = airnight3_wave.spr, attached, (age, 10)
```

#### Arguments:

- File Name
- Dependency on parent (direct ascendant) (_attached_/_nonattached_)
- Spawn Time
  - `interval`
    - Interval
    - Count
  - `onground`
  - `ondeath`
  - `age`
    - Time (ms/frames)

### `Add_Rotation`

```
:Add_Rotation = (1, 1, 1), (0, 2d, 50000, 2d)
```

#### Arguments:

- Rotation Axis Direction
  - `x`
  - `y`
  - `z`
- Start/End Values
  - Start Time (ms/frames)
  - Start Angular Velocity (deg/rad)
  - End Time (ms/frames)
  - End Angular Velocity (deg/rad)

### `Add_NRotation`

```
:Add_NRotation = (1, 1, 1), (0, 2d, 50000, 2d)
```

#### Arguments:

- Rotation Axis Direction
  - `x`
  - `y`
  - `z`
- Start/End Values
  - Start Time (ms/frames)
  - Start Angular Velocity (deg/rad)
  - End Time (ms/frames)
  - End Angular Velocity (deg/rad)

### `Add_Revolution`

```
:Add_Revolution = ((0, 0, 0), (0, 1, 0)), (0, 1.0d, 20000, 1.0d)
```

#### Arguments:

- Rotational Values
  - Rotational Axis Position
    - `x`
    - `y`
    - `z`
  - Rotational Axis Direction
    - `x`
    - `y`
    - `z`
- Start/End Values
  - Start Time (ms/frames)
  - Start Angular Velocity (deg/rad)
  - End Time (ms/frames)
  - End Angular Velocity (deg/rad)

### `Add_PRevolution`

```
:Add_PRevolution = ((0, 0, 0), (1, 0, 0)), (0, 1.0d, 20000, 1.0d)
```

#### Arguments:

- Rotational Values
  - Rotational Axis Position
    - `x`
    - `y`
    - `z`
  - Rotational Axis Direction
    - `x`
    - `y`
    - `z`
- Start/End Values
  - Start Time (ms/frames)
  - Start Angular Velocity (deg/rad)
  - End Time (ms/frames)
  - End Angular Velocity (deg/rad)

### `AttachedToParent`

```
:AttachedToParent = on, (1, 1, 1)
```

#### Arguments:

- Dependency (_on_/_off_)
- Dependent Axis (0 = off, 1 = on)
  - `x`
  - `y`
  - `z`

### `stop`

```
29000: stop
```

#### Arguments:

_None_

### `goto`

```
4600: goto = loop_a
```

#### Arguments:

- Label Name
