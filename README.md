# BraudeTimetabler - As will be presented at Reversim Summit 2018 

*Developed by On & Mey

This is the source code for the Braude Timetabler web-app.

You can view it at: http://timetabler.azurewebsites.net/

Background:
============
Starting a new  semester was never easy for me as a student,
but the one thing I hated the most was planning my semester timetable.
The usual practice was to assemble my timetable manually : 
1. I chose one group of each course class-type (lecture/tutorial/lab/other) available:

BraudeTimetabler/ReadMeEssentials/coursesList.png


 2. I inserted the chosen groups into an empty timetable and checked if it answered my needs and constraints.       If it didn't i’d try again and again until I managed to find a good timetable. 

BraudeTimetabler/ReadMeEssentials/timeTableExample.png


I wanted to assemble a timetable that fit certain constraints and needs I had such as: number of days off, a maximum gap of one hour between classes etc. therefore this is a constraint satisfaction problem.

In order to find the BEST timetable I had to explore all possible timetables and as a software developer I knew that there must be an algorithm that could solve this problem for me. 

The first algorithm I used was Backtracking. My Backtracking algorithm was set to return the BEST SOLUTION, after generating and examining ALL POSSIBLE SOLUTIONS.  
When I ran this algorithm with only 2-3 courses it worked wonderfully but when I ran this algorithm with 6 courses - the algorithm kept on running and didn’t stop. An answer was never received.  A quick calculation revealed a terrible fact: in the worst case scenario it might take up to 2 million years to go through all the possible solutions. As the semester was about to begin I didn't have enough time to wait. 

**** This project runs Backtracking in one thread ****

For more then 2-3 courses I needed a better, faster algorithm. 
I turned to *Genetic Algorithms* as they are also known to be good for solving scheduling problems. 
My Genetic algorithm for this problem didn’t look for ALL possible solutions, it looked for a “good enough solution”. 
Sometime having a “good enough” solution is more important than having the very best solution especially when calculation time is so crucial! By defining what is a “good enough” solution,

 I was able to construct the following algorithm: 

     1. Generate random solutions

     2. Find their fitness - Grade them (Higher is better) :

      All timetables were graded the following way: 
      
      * Assemble each constraint with a different weight, according to its importance for me. 
      * Run a check for each constraint
   	    For example:  grading a timetable by the number of days off it had was done by grading each day off 
        with 10 ‘points’. 
        A timetable with no days off will be the worst (graded 0) and a timetable with
        4 days off would be the best, 2-3 days off is good enough.
      * Finally sum up all grades from received from each constraint - this is the final grade of one timetable.

     3. Save only the best solutions found (the ones with the highest score) 

     4. Use the chosen solutions to re-generate more solutions :
        New solutions were generated the following way: 
            Merge two solutions by taking half of each solution (crossover step)
            In the new merged solution randomly change one class group into a different group in order to create             totally new solutions. 
            This step was not executed on all of the new timetables,
            but randomly chose 2-3 timetables and performed it on them. (mutation step with mutation rate)

      5. Go back to step 2 until a good enough solution was found. 


Screenshots:
==============
1. choose Courses from list: 
BraudeTimetabler/ReadMeEssentials/timeTableScreenshot1.png
