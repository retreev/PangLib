# IFF - `*.iff`

The IFF (Interchangable File Format/_Item File Format_) files contain metadata of Pangya, this includes availability flags, dates, names, model references and more.

There are two different types of IFF files, one are a simple archive format, and the other one are the actual IFF files. You can extract the IFF archives with any conventional extraction tool, programmatically you can easily make them out as they start with `PK`.

Besides the general sizes of native types like `byte`, `ushort` and `uint`, strings in IFF files have a length of 40 bytes.

An IFF file only ever includes one type of record, which you can make out by the name of the file the easiest.

## File Structure

### File Header

Right at the beginning of the file there's the file header:

```csharp
struct IFFHeader
{
    ushort RecordCount;
    ushort BindingID;
    uint   Version;
}
```

* **RecordCount**: Count of data sets inside this file
* **BindingID**: A overarching ID matching with the whole IFF metadata set (data is bound together)
* **Version**: Revision or Version of the IFF file (usually between 11-13)

### Common IFF Data

Most IFF files include a common beginning of the data structure, the only exemptions to this are:

- `CadieMagicBox`
- `CadieMagicBoxRandom`
- `CutinInfomation`
- `Description`
- `FurnitureAbility`
- `Match`
- `OfflineShop`
- `TikiPointTable`
- `TikiRecipe`
- `TikiSpecialTable`

The `_SYSTEMTIME` type used in this structure is based on the equally called [system structure](<https://msdn.microsoft.com/en-us/library/windows/desktop/ms724950(v=vs.85).aspx>).

```csharp
struct IFFCommon
{
    public uint Active;
    public uint ID;
    public string Name;
    public byte Level;
    public string Icon;
    public uint Price;
    public uint DiscountPrice;
    public uint UsedPrice;
    public byte ShopFlag;
    public byte MoneyFlag;
    public byte TimeFlag;
    public byte TimeByte;
    public uint Point;
    public _SYSTEMTIME StartTime;
    public _SYSTEMTIME EndTime;
}
```

**Note:** The previously assumed _magic number_ (between byte 4-8) is actually a version/revision number. It's notable that between those revisions some structures in the common data fields
and probably in other places have changed.

The rest of the file or the structure in general is based on the individual file/record type, you can find the definition of the other structures in `Documentation/Formats/IFF/Models`.

Across the structures, there are also a multitude of flags used, like `ShopFlag` or `MoneyFlag` from the common IFF structure. These structures are documented in `Documentation/Formats/IFF/BitFlags`.
