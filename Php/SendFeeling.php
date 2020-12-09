<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Variables from user app (Unity)
$studentId = $_POST['studentId']; // Fill with unique student ID
$feelingScore = $_POST['feelingScore']; // Fill with feeling (1 to 5)
$feelingComment = mysqli_real_escape_string($_POST['feelingComment']); // Fill with optional comment
$timestamp = date('Y-m-d'); // Current day (year, month, day)

$feedback = $conn->DbInsert('feelings', 'student_id, score, comment, created_at', "{$studentId}, {$feelingScore}, '{$feelingComment}', '{$timestamp}'");

// echo $studentId;
// echo "      ";
// echo $feelingScore;
// echo "      ";
// echo $feelingComment;
// echo "      ";
// echo $timestamp;

if ($feedback == false) {
  echo("It broke, feedback boolean is false");
}

$conn->DbClose();

?>