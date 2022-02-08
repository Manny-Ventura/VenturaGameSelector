There are some things you probably haven't seen before in the Starter code.  I
encourage you not to just copy/paste your code.

Enums are used fairly extensively here.  Enums are a little different in
each language.  You can think of them as a constant, but grouped
together with a specific type.  The enum is a data type similar to a class.
(In Java, they are even more like classes in that they can have methods.)
In this code, we will simply use the idea that you can Enums int HashSets and
into Lists.  We will use both.

Here is an overview of the code that exists.  It goes a long way toward creating
a user interface and the underlying model classes.  The Game and GameSet classes
are pretty simple.

The 'Console' class should also be fairly simple.  It is broken up into fairly
small modules, that present menus and then modfiy the GameSelector object based
on input from the user.  It is fairly well separated from the GameSelector
class, which knows nothing of its user interface.  If we were working with a
GUI, we would hopefully be able to user the model as is (well, including the
enhancements that you will make).

The complexity is mainly in the GameSelector class.  This class currently has
three major data structures.  One is the AllGames set.  This set holds all of
the games.  It is a Set since we only want one game represented.  It also allows
us to initialize our starting set each time. Note that although it is marked
readonly, it can be modified.  We would need IImmutableSet, or something similar
for the AllGames to be truly unmodifiable.

Another data structure is the dictionary which contains 'game criteria'.  It is
a dictionary of GameSets which holds the 'pre-built' sets, e.g. all Strategy
games, all Diplomacy games, all Board games, etc. These are currently accessed
by the names of their Genre; you will want to add names based on media,
difficulty and perhaps others, depending on your design.

The third data structure, currentGenreList is Genre specific.  The first two
data structures will remain unchanged througout the program.  This data
structure holds a list of the Genres that the user has indicated an interest in
and will change depending on the selections that the user makes regarding
the Genres.  You will probably want something similar for Media and probably
Difficulty.

There are methods for modifying the genre list.  These could be called singly,
but our UI code will call RetrieveCurrentMatches after each call.  Again, this
isn't necessary and you may want to work this differently.  The
RetrieveCurrentMatches method (for now) simply walks through the current genres
and Unions them; that is, it adds them all into a single set.  Then it
Intersects that set with the current matches (which was set to be AllGames).
The assumption is that if a user chooses Diplomacy and Strategy it means they
are looking for diplomacy OR strategy games, not games that are both diplomacy
and strategy.  The same is true of media.  It is not true of all the criteria,
however.  For example, a user will replace the time limitations, since there is
no need to have less that three ours OR less than four hours since the first is
covered by the second.  You may want to think about how to implement this type
of criteria.  You may want to have another overarching data structure that keeps
track of all the criteria, or perhaps an array of lists, or Dictionary of lists.
There are multiple ways you could approach this.  Once you have designed your
approach, you will need to modify the code in RetrieveCurrentMatches to match
whatever you do as far as data structures goes.

Work through things a little at a time.  Add Media and get it working, the choose
one of the other criteria and get it working.  Don't try to do everything at
once as it is pretty easy to get lost.

Good luck!
