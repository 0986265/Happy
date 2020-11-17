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

// Get data
$sql = "SELECT * FROM students WHERE email = 'test@student.com'";
$result = $conn->query($sql);

if($result->num_rows > 0){

    while($row = $result->fetch_assoc()){
        /*
        * Set max lenght of the new password
        * Shuffle the string and return a new string with a length of 10
        * Hashed the password with php function
        */ 
        $length = 10;    
        $newPass = substr(str_shuffle('0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ'),0,$length);
        $hashedPass = password_hash($newPass, PASSWORD_DEFAULT, ['cost' => 12]);
     
        $newSQL = "UPDATE students SET nickname='{$newPass}', password='{$hashedPass}' WHERE id={$row['id']}";

        if($conn->query($newSQL)){
            echo "New passport is {$newPass}";
        }else{
            echo "Password failed";
        }
        
    }
}else {
    echo "Email does not exist";
}


?>