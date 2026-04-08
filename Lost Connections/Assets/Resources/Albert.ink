Do you message Albert?

 * Yes
 -> socialY
 * No
 -> socialN

=== socialY ===
# E.SocialY
- You text Albert but get left on read. Ouch.
#E.Delay3.Last
    -> END
    
=== socialN ===
# E.SocialY
- You decide not to text Albert, probably for the better.
#E.Delay3.Last
-> END
