<?php
  require 'DatabaseConn.php';

  // Create connection
  $conn = new DbConn;

// Variables from user app (Unity)
$studentId = $_POST['userID']; // Fill with unique student ID
$feelingScore = $_POST['feelingScore']; // Fill with feeling (1 to 5)
$feelingComment = htmlentities($_POST['feelingComment']); // Fill with optional comment
$timestamp = date('Y-m-d'); // Current day (year, month, day)

$sql = "INSERT INTO feelings (student_id, score, comment, created_at) VALUES ('$studentId', '$feelingScore', '$feelingComment', '$timestamp')";

$feedback = $conn->DbInsert('feelings', 'student_id, score, comment, created_at', "'{$studentId}', '{$feelingScore}', '{$feelinComment}', '{$timestamp}'");

if ($feedback == false) {
  console.log("It broke, feedback boolean is false");
}

$conn->DbClose();

?>