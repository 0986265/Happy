<?php

    class DbConn{

        private $servername = "boostworks.online";
        private $username = "boostworksonline_ced-app";
        private $password = "SyoYiTgKYj$6925&aF3y";
        private $db = "boostworksonline_ced";
        private $conn;

        function __construct(){
            try{
                // Create connection
                $this->conn = new mysqli($this->servername, $this->username, $this->password, $this->db);
            } catch(Exception $error){
                echo "<h1>Connection error {$error->message()}" ;
            }
        }

        public function DbSelect($selected_columns, $table, $where_claus = null){
            $sql = "SELECT {$selected_columns} FROM {$table} ". ($where_claus != null ? "WHERE {$where_claus};" : ";");
            return $this->conn->query($sql);

        }

        public function DbUpdate($table, $update, $where_claus = null){
            // $sql = "Update {$table} SET {$update} " . ($where_claus != null ? "WHERE {$where_claus};" : ";");
            // return $this->conn->query($sql);

            $sql = "UPDATE {$table} SET {$update} ". ($where_claus != null ? "WHERE {$where_claus};" : ";");
            return $this->conn->query($sql);
        }

    }

?>