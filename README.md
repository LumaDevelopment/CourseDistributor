﻿# CourseDistributor
## Background
As a student at a small, private university with exactly 52 transfer credits, deciding my schedule can be... complicated. I have a target semester for when I want to graduate, and unfortunately, coming up with a course plan that can get me there is no small feat. Once one factors in prerequisites, chains of courses, and courses only being offered in fall or spring, straying from the catalog is dangerous business. Recently, I've had to redo my course plan a couple of times, and I found myself thinking 'there has to be a better way'.

So, I decided to make one. My normal approach to this problem would be to grab a cup of coffee, boot up my IDE, and start making a Java console app. However, recently I've been trying to make projects with a wider span of langauges and frameworks (particularly <a href="https://github.com/LumaDevelopment/Velox">Android</a> and <a href="https://github.com/LumaDevelopment/Rampazetto">Python</a>), so I decided to make this in ~~the language most commonly compared to Java~~ a language I've never used before, C#

## Functionality
- Add/edit/remove courses
- Add/edit/remove/reorder semesters
- Automatically distribute courses across semesters based on:
	- The amount of courses dependent on other courses
	- The fall/spring/both availability of courses
	- The number of prerequisites a course has
	- etc.

## Gallery
<img src="img/mainForm.png" width="85%">
<img src="img/addEditCourseForm.png" width="40%">
<img src="img/addEditSemesterForm.png" width="50%">