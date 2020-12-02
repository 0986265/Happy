
<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Get data
$result = $conn->DbSelect('*', 'students', "email='b@o.com'");

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
      $return["id"] = $row["id"];
      $return["firstname"] = $row["first_name"];
      $return["lastname"] = $row["last_name"];
      $return["email"] = $row["email"];
      $return["nickname"] = $row["nickname"];
      $return["active"] = $row["active"];
      $return["avatar"] = $row["avatar"];
      $return["color"] = $row["color"];
      
      $studentId = $return["id"];
    }
} else {
  echo "Query failed";
}

// Get feelings date of loged in student
$result2 = $conn->DbSelect('created_at', 'feelings', "student_id='{$studentId}' ORDER BY created_at DESC LIMIT 1");
if ($result2->num_rows > 0) {
  // output data of each row
  while($row = $result2->fetch_assoc()) {
    $latestFeeling = $row["created_at"];
  }
} else {
  echo "Error while getting last inserted feeling (database: feelings)";
}



// Converting dates to timestamps
$dateToday = date("Y-m-d");
$dateTimestamp1 = strtotime($latestFeeling); 
$dateTimestamp2 = strtotime($dateToday); 
  
// Compare the timestamp date
if ($dateTimestamp1 >= $dateTimestamp2) {
  echo "false";
} else {
  echo "true";
}

$conn->DbClose();

?>