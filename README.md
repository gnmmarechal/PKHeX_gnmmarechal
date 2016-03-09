PKHeX: Gnmmarechal's Edition
=====

THIS WILL BE RENDERED OBSOLETE BY THE NEXT PKHEX RELEASE --> My code is crap, and the official PKHeX will have most of these (if not all) features. Anyway. I'll eventually fork PKHeX properly.

Pokémon X/Y/OR/AS SAV/PKX Editor based on PKHeX (https://github.com/kwsch/PKHeX)

Some current PKHeX features might be unavailable. This is because I don't update the core PKHeX code to follow the original program.
WC6 to PK6 conversion is not available, as that's a more recent feature. I may add it later, after finishing the Location Fixer, or just take the new source code and paste my changes over it. GSPKHeX is used best for regular genning. WC6->PK6 will have to be done with the official PKHeX.

Also, I'm aware there are significantly better ways to write the code. Mine may be the worst, but it gets the job done for me. I'll eventually rewrite the whole thing, and base myself on a more recent version of PKHeX.

Supports Legality Checker (WIP):
* Automatically fills location and met level of Pokémon (WIP)
* Checks legal moves (Planned)

Supports binary file loading of:
* Decrypted Save files (1MB/Cyber Save 0x65600/0x76000 Bytes)
* Individual entity files (232/260 bytes)
* Wondercard gifts for Event Pokemon and Event based Items.
* Obsoleted: Unencrypted Network Packets containing entity files.

Data is then displayed in a meaningful view, and can be edited and saved back to binary data.
For loaded save files, saving an edited copy is possible and all hashes will be fixed.
Since save data uses an AES MAC that cannot be emulated without the 3DS's keys, a resigning service is required.

The interface is translatable with resource/external text files so that different languages can be supported.

## Screenshots

![Main Window](https://raw.githubusercontent.com/gnmmarechal/PKHeX_gnmmarechal/master/screenshot.png)

### License

PKHeX: Gnmmarechal's Edition is licensed under GPLv3. Refer to LICENSE.md for more information.

## Building

PKHeX: Gnmmarechal's Edition can be compiled with any C# compiler.

### IDE

It is easy with MS Visual Studio and [MonoDevelop](http://www.monodevelop.com/).
You can import the project with the .sln file.

### Command line

You can use [xbuild of Mono](http://mono-framework.com/Microsoft.Build): `xbuild PKHeX.sln`.

### GNU/Linux

On Debian, you can install MonoDevelop and [Mono](http://www.mono-project.com/) runtime with `sudo apt-get install monodevelop`.
The project uses System.Deployment, unfortunately - even with version 4.0 - [it is not implemented in Mono](https://stackoverflow.com/questions/9112460/mono-develop-assembly-system-deployment-not-found).
There is the same problem with [System.Data.SqlServerCe (SQL Server Compact Edition)](https://stackoverflow.com/questions/2644464/can-i-use-sql-server-compact-edition-ce-on-mono) (that could be replaced by [SQLite](https://en.wikipedia.org/wiki/SQLite), that is free/libre cross-platform [RDBMS](https://en.wikipedia.org/wiki/Relational_database_management_system) to avoid the problem).
At least in 2015, GNU/Linux is not the main OS of developers of this program, so there are bugs, but some may come from non GNU/Linux specific code of Mono (so developers using *BSD, Windows and OS X should be able to reproduce them).
