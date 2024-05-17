# Intro
Die Fahrschulen API (und deren UIs) ist ein Schul Projekt, welches von Behnoush T. und Dominik S.
für das Schulfach LF12a erstellt worden ist. 

# Was kann das projekt?
Vorab -> Diese Anwendung besitzt keine Authentifizierung, weshalb mit hard codierten Ids für "den Lehrer" und "den Schüler" gearbeitet worden ist.
Es wurde zwar angefangen einen JwtToken Generator zu Schreiben, jedoch wird dieser aktuell nicht genutzt.

Admin:
Der Admin kann Schüler und Lehrer anlegen und kann deren persönliche Daten editieren. (Er hat dabei kein eigenes Profil)

Lehrer:
Ein Lehrer kann sein eigenes Profil einsehen und editieren (nur bestimmte properties). Wenn ihm ein oder mehrere Schüler zugewiesen worden sind (der Admin eine Lehrer Id beim Anlegen / Editieren eines Schülers hinterlegt hat),
so kann er sich diese auflisten lassen und deren Profile ansehen. Zudem ist er in der Lage einen Termin Vorschläge an Schüler zu senden.

Schüler:
Ein Schüler kann sein eigenes Profil einsehen und editieren (nur bestimmte properties). Wenn dem Schüler ein Termin Vorschlag gesendet worden ist, so kann der Schüler den Termin annehmen oder auch ablehnen.

# How to use
-> Folge den Anweisungen der "InstallationsGuideFahrschule" Datei
