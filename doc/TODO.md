TODO
====

Things what need doing.

General
-------

* Recognize commands.

* Tick method for objects that fires after each command.

   * (Keep list of objects that need it in main).


Specific
--------

* Exits.cs:

  * Support more verbose exit methods such as "there is a door here leading to
    a small closet"

  * Support unexitable exits with a failure string such as "the door is closed"
    or "you don't want to."

* Item.cs:

  * Support non-pickupable items. Things like this can include unmovable but
    interactable things in the room.

<!-- vi: ft=markdown spell
-->
