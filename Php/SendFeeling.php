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

// Variables from user app
$feelingScore = $_POST['feelingScore']; // Fill with feeling (1 to 5)
$feelingComment = $_POST['feelingComment']; // Fill with optional comment

$id = "SELECT id FROM students WHERE email = '" . $loginEmail . "'";

$resultId = $conn->query($id);

$sql = "INSERT INTO feelings (student_id, score, comment) VALUES ('$id', '$feelingScore', '$feelingComment')";

$conn->close();

?>