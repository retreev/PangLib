# MOT - `*.mot`

The MOT (Motion) file format seems to be related to defining motions of a Pangya caddie.

The file name of a MOT file is the shortname of the caddie, also found in the IFF definition (e.g. `bon` for Papel).

## File Structure

MOT files don't contain a lot of data, but it seems they contain a value tied to a state/event. The values are numeric and the states/events are korean strings.

Most caddies have following content in their MOT file:

```
2:달리기    // Running
1:기다리기  // Waiting
1:재촉하기  // Prompting
0:홀인원    // Hole-in-One
0:홀인     // Hole-In
0:실격     // Disqualification
0:찬스     // Chance
```

This is still to be investigated, but maybe the numeric value defines behaviour on that event happening, and `0` simply disabling it, as for Papel (`bon`) every single value is `0`.
