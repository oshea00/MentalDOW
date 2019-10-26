# Mental Day Of Week Kata

A solution for the day of week (without using a date library) Kata.

I use this method to mentally determine the day of the week given a valid
US Gregorian date (dates valid on or after September 14th, 1752)

The method requires memorization of 15 numbers (century offset and month code)
combined with knowing the rule for determining a leap year. Sprinkle with
a little modulo 7 and modulo 4 math and viola!


