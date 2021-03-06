# ZX Spectrum Memory Tool Window Commands

## Navigation Command

__`G`__ *`hexnum`*

Sets the top position of the ZX Spectrum tool window to the specified address. _Note:_ The tool window displays 
the memory contents in 8-byte sections, so the given address is aligned to the closest segment.

## Banking Commands

_Note:_ This commands are available with the Spectrum 128K, Spectrum +3E, and Spectrum Next models only.

### Select ROM Page

__`R`__ *`romindex`*

Displays the ROM with the specified index. When showing the memory contents, the addresses between `#0000` 
and `#3fff` display the contents of this ROM. With a Spectrum 128K, you can use indexes `0` or `1`, as this model has two ROMs.
With a Spectrum +3E model, you can use indexes from `0` to `3`, supporting the four ROMs of such a model.

In this mode, the tool window displays only the contents of the selected ROM, and no other parts of the memory.

### Select Memory Bank

__`B`__ *`bankindex`*

Displays the RAM bank with the specified index. When displaying the memory contents, the addresses between `#0000` 
and `#3fff` display the contents of this RAM bank. Indexes can be between `0` and `7`.

In this mode, the tool window displays only the contents of the selected RAM bank, and no other parts of the memory.

### Select Full Memory Mode

__`M`__

Displays the entire addressable (64K) memory, exactly as the Z80 CPU sees it. Displays the currently selected RAM
in the `#0000`..`#3FFF` address range, Bank 5 in the `#4000`..`#7FFF` range, Bank 2 between `#8000` and `#BFFF`.
Uses the currently paged bank for the `#C000`..`#FFFF` range.

_Note_: Right now, the memory view cannot handle the special banking modes available in the Spectrum +3E model (through the `#1ffd` port).
This feature will be implemented later.
