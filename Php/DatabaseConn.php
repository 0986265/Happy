<?php

    class DbConn{

        private $servername = "boostworks.online";
        private $username = "boostworksonline_ced-app";
        private $password = "SyoYiTgKYj$6925&aF3y";
        private $db = "boostworksonline_ced";
        private $conn;

        // Connect to database once this class is instantiated
        function __construct(){
            try{
                // Create connection
                $this->conn = new mysqli($this->servername, $this->username, $this->password, $this->db);
            } catch(Exception $error){
                echo "<h1>Connection error {$error->message()}" ;
            }
        }

        // Select query with an optional last parameter
        public function DbSelect($selected_columns, $table, $where_claus = null){
            $sql = "SELECT {$selected_columns} FROM {$table} ". ($where_claus != null ? "WHERE {$where_claus};" : ";");
            return $this->conn->query($sql);

        }

        // Update query with an optional last parameter
        public function DbUpdate($table, $update, $where_claus = null){
            $sql = "UPDATE {$table} SET {$update} ". ($where_claus != null ? "WHERE {$where_claus};" : ";");
            return $this->conn->query($sql);
        }

        // Insert query 
        public function DbInsert($table, $columns, $values){
            $sql = "INSERT INTO {$table} ({$columns}) VALUES ({$values})";
            return $this->conn->query($sql);
        }

        public function DbClose(){
            $this->conn->close();
        }

    }

?>