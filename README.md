<div align='center'>
<img src='https://i.imgur.com/yGUYWQk.png' width="300">
</div>

<br />

<!-- TABLE OF CONTENTS -->
<h2 id="table-of-contents"> :book: Table of Contents</h2>

<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#about-the-project"> ➤ About The Project</a></li>
    <li><a href="#prerequisites"> ➤ Prerequisites</a></li>
    <li><a href="#mvp"> ➤ Minimum Viable Project</a></li>
    <li><a href="#core-features"> ➤ Core Features</a></li>
    <li><a href="#uml-diagram"> ➤ UML Diagram</a></li>
    <li><a href="#demo"> ➤ Demo</a></li>
    <li><a href="#process"> ➤ Process</a></li>
    <li><a href="#execute"> ➤ Execute a Sprint</a></li>
    <li><a href="#devops"> ➤ Azure DevOps</a></li>
    <li><a href="#contributors"> ➤ Contributors</a></li>
  </ol>
</details>


<img src='https://i.imgur.com/DwCJ72P.png'>

<!-- ABOUT THE PROJECT -->
<h2 id="about-the-project"> :pencil: About The Project</h2>

<!--
<p align="justify"> 
  This application was built as the capstone project for the Thinkful Software Engineering Flex Program. It was designed to be used by restaurant personnel to keep track of reservations and table seating, when a request is made by a customer.
</p>
-->

<table>
<tr>
<td>
  This application was built as part of the Microsoft Leap Apprenticeship Program by a Team of 4 Software Engineers and a Technical Program Manager, where they put together a console game for The Wheel of Fortune, which has contestants solve word puzzles to win cash prizes determined by spinning a giant carnival wheel. The rules of the game can be found at: <a href="https://en.wikipedia.org/wiki/Wheel_of_Fortune_(American_game_show)">https://en.wikipedia.org/wiki/Wheel_of_Fortune_(American_game_show)</a>
  
  
</td>
</tr>
</table>

<img src='https://i.imgur.com/DwCJ72P.png'>

<!-- PREREQUISITES -->
<h2 id="prerequisites"> :fork_and_knife: Prerequisites</h2>

The following tech stack was used in this project:
* C#
* .NET framework
* Azure DevOps

<img src='https://i.imgur.com/DwCJ72P.png'>

<!-- Minimum Viable Project -->
<h2 id="mvp"> :book: Minimum Viable Product</h2>

1. Supports one player
1. Choose a string 
   - Hardcoded is fine
   - Display dashes for missing letterse 
1. Allow current player to guess letters     
   - If letter is in the word, replace underscores with matching letters
   - If letter is not in word, let player know and keep playing    
1. Allow current player to solve   
   - If guess is correct (not case sensitive), player wins
   - If guess is not correct, keep playing
     
<img src='https://i.imgur.com/DwCJ72P.png'>

<!-- Core Features -->
<h2 id="core-features"> :iphone: Core Features</h2>

1. Support 3 players  
   - Collect and display each player’s name 
1. Each player can win money, starts with $0     
   - Display total money and money for current round   
1. “Spin” for dollar value  
   - Don’t worry about buying vowels, just spin for them as normal
   - Lose a turn should be an option and it should immediately end the current turn
   - Bankrupt should be an option and it should wipe out money for the current round (not total money)
   - The dollar values should go up every round
1. More guess actions:
   - If current player gets a letter right, award them the spin value for each letter and go again 
     - If the letter is already guessed, it counts as a wrong letter  
   - If current player gets a letter wrong, turn is over
   - If current player solves correctly, round is over, they win
   - If current player solves incorrectly, turn is over
   - If guess is not correct, keep playing
1. When a player wins a round:
   - Their current round money is added to their total money
   - All other players lose their current round money (but their total money is not affected)
1. Support 3 rounds
1. Game winner is player with most money at the end of the game

<img src='https://i.imgur.com/DwCJ72P.png'>

<!-- UML Diagram -->
<h2 id="uml-diagram"> :newspaper: UML Diagram</h2>

The UML Diagram displays the relationship between the different classes:
    
<img src='https://i.imgur.com/EeCKRYF.png'>

<img src='https://i.imgur.com/DwCJ72P.png'>

<!-- DEMO -->
<h2 id="demo"> :cloud: Demo</h2>

<!--
Here is a live demo: <a href="https://capstone-rest.herokuapp.com/dashboard">https://capstone-rest.herokuapp.com/dashboard</a> -->

<div>
<img src='https://i.imgur.com/h2v1MCm.gifg'>
</div>

<img src='https://i.imgur.com/DwCJ72P.png'>

<!-- PROCESS -->
<h2 id="process"> :grey_exclamation: Process</h2>

1. Think about what user stories are required for the game to work. Use Azure DevOps to create your team’s Epics, Features, User Stories, etc. Remember to start working in your backlog.
   - Focus on the entire game, not just the MVP
1. Break down your High-level items into tasks.
1. At this phase, focus on business requirements, not implementation details. Dev breakdown with implementation details will come later.
1. Prioritize and estimate times for your high-level items.
1. Find the work items that make up your minimum viable product (MVP), and add them to 
the sprint.
   - The amount of work in your MVP should reflect that amount of time you have put aside not only to write code, but write tests, make sure everyone is comfortable committing, setting up the project etc.
1. Distribute the tasks amongst your team.
   - It is highly recommended to engage in domain modeling and class diagrams to help divide up the work
1. Create child tasks of the user stories, which include implementation details (data structures, algorithms, etc.) and technical requirements
   - The child tasks should each have a time estimate. 

<img src='https://i.imgur.com/DwCJ72P.png'>


<!-- EXECUTE A SPRINT -->
<h2 id="execute"> :small_orange_diamond: Execute a Sprint</h2>

1. Each team member should create a branch in order to work (and complete) a work item.
1. When ready, each team member should create a pull request from their personal remote branch into the staging branch.
1. The team should be performing code reviews to make sure the team branch stays healthy. You may use a ‘lead developer role’ that is present for accepting and managing pull requests. Asking a TPM to do all code reviews is incorrect.
1. Find the work items that make up your minimum viable product (MVP), and add them to 
the sprint.

<img src='https://i.imgur.com/DwCJ72P.png'>

<!-- AZURE DEVOPS -->
<h2 id="devops"> :scroll: Azure DevOps</h2>

<img src='https://i.imgur.com/FCzSMUX.png'>

<img src='https://i.imgur.com/DwCJ72P.png'>

<!-- CONTRIBUTORS -->
<h2 id="contributors"> :scroll: Contributors</h2>

| Contributors                                            | Contact Info                                                                                                         
| -------------------------------------------------------- | ---------------------------------------------------------------------------
| Anthony Sim, SWE                                          | https://www.linkedin.com/in/sim-anthony/                                     
| Douglas MacKrell, SWE                           | https://www.linkedin.com/in/douglasmackrell/
| Rouan Ulep, SWE                    | https://www.linkedin.com/in/rulep/
| Stacy Desgranges, TPM                                               | https://www.linkedin.com/in/stacy-r-desgranges-mpp-csm-itil-5b9288aa/
| Trey Danks, SWE                                     | https://www.linkedin.com/in/harold-danks/ 