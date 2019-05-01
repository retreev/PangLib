# QST - `*.qst`

The QST (Quest) file format is a dialogue format containing information of the event-split story dialogue of Pangya: Fantasy Golf for the PSP.

## File Structure

The file structure of QST files is quite simple. The first byte is the amount of dialogue structures being present in the file.

### Dialogue Structure

```csharp
public struct QSTDialogue 
{
    public byte EventID;
    public byte ID;
    public byte CharacterID;
    public byte Position;
    public string CharacterImage; // 32 bytes
    public string BackgroundImage; // 32 bytes
    public string Text; // 192 bytes
}
```

**Note:** I only made assumptions about `CharacterID` and `Position`. Both of these values change with who's speaking and the current line of text, so it's not easy to make out what exactly they are for.

After this structure, there are 8 additional bytes of data, which sometimes are completely empty or contain bytes at random positions. I haven't figured out what they are there for yet. I just skipped them in `PangLib.PSP.QST`.