# Update List - `updatelist`

Update lists are files which tell the updater about patches and the changed/included files
and metadata about those.

You can't read update lists right away, as they are encrypted using XTEA and the region-specific
key, but once they are decrypted, they are a simple XML format.

A simple but invalid XML format, as it includes multiple root nodes, so conventional XML parsers
will refuse to interpret it.

## File Format

```xml
<?xml version="1.0" encoding="euc-kr" standalone="yes" ?>
<patchVer value="GB.R7.852.00" />
<patchNum value="306" />
<updatelistVer value="20090331" />
<updatefiles count="2">
	<fileinfo fname="binkawin.asi" fdir="\mss" fsize="56320" fcrc="-13704566" fdate="2013-10-22" ftime="07:41:57" pname="binkawin.asi.zip" psize="32364" />
	<fileinfo fname="mssdolby.flt" fdir="\mss" fsize="7680" fcrc="-33883344" fdate="2013-10-22" ftime="07:41:56" pname="mssdolby.flt.zip" psize="2998" />
</updatefiles>
```

### `patchVer`

This value includes the name of the current version

### `patchNum`

This value includes the current iteration of the patch (patch index)

### `updatelistVer`

Version number of the updatelist specification

### `updatefiles`

List of all files included

**Attributes:**

- `count` - Number of files to be patched

### `fileinfo`

File included in the patch

**Attributes:**

- `fname` - File Name
- `fdir` - Target directory of the file inside the game folder (empty = root)
- `fsize` - File Size
- `fcrc` - Checksum
- `fdate` - Creation Date
- `ftime` - Creation Time
- `pname` - Package Name
- `psize` - Package Size
