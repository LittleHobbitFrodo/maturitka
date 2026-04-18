#!/bin/bash

#   Vygeneruje prompt pro chatjippity aby vythovl obsah otazky v markdownu
#       CATne danej soubor a prida ho k promptu, pak to zkopiruje do clipboardu
#   NOTE: kopirovani do clipboardu funguje jen na macos

if [ "$#" -ne 1 ]; then
    echo "Chybí soubor"
    exit 1
fi

PROMPT="Vytvoř obash (v markdownu) pro můj dokument: použij číslované (nested)
body, každý bod je nadpis v dokumentu a odkazuje na daný nadpis, pracuj pouze
s nadpisy do čtvrté úrovně nepřidávej nadpis 'Obsah'. Pracuj v korektním markdownu a s touto osnovou: "

#TITLES="$(cat $1 | grep -E "^#")"
echo -e "$PROMPT\n$(cat "$1" | grep -E '^#')" | pbcopy
