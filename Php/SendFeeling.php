<?php
$servername = "boostworks.online";
$username = "boostworksonline_ced-app";
$password = "SyoYiTgKYj$6925&aF3y";
$db = "boostworksonline_ced";

// Create connection
$conn = new mysqli($servername, $username, $password, $db);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

// Variables from user app (Unity)
$studentId = $_POST['studentId']; // Fill with unique student ID
$feelingScore = $_POST['feelingScore']; // Fill with feeling (1 to 5)
$feelingComment = htmlentities($_POST['feelingComment']); // Fill with optional comment
$timestamp = date('Y-m-d'); // Current day (year, month, day)

// Debugging echos
echo($studentId);
echo($feelingScore);
echo($feelingComment);

$sql = "INSERT INTO feelings (student_id, score, comment, created_at) VALUES ('$studentId', '$feelingScore', '$feelingComment', '$timestamp')";

$feedback = $conn->query($sql);

if ($feedback == false) {
  echo("It broke, feedback boolean is false");
}

$conn->close();

?>