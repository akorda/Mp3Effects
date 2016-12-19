# MusicUtils

## mp3fx command line tool that helps you raise or lower the pitch of an .mp3 file

USAGE:

Lower the pitch of a song by 2 semitones. The output file will be 'song-2.mp3':

####   mp3fx song.mp3 -2

Raise the pitch of a song by 3 semitones. The output file will be 'song+3.mp3':

####   mp3fx song.mp3 3

Raise the pitch of a song by 1 semitone. The output file will be 'modified.mp3':

####   mp3fx --output modified.mp3 song.mp3 1

PARAMETERS:

  -o, --output                       Output filename

  --help                             Display this help screen.

  --version                          Display version information.

  mp3 (pos. 0)                       Required. The mp3 file to apply the effects

  semitones (half-steps) (pos. 1)    Required. The semitones to change the pitch. Any positive or negative value,
                                     different that 0, is suitable
