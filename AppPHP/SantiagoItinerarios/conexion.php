<?php
 // Connects to Our Database
 $connection = mysql_connect("localhost", "arceing", "pechuga") or die(mysql_error());
 mysql_select_db("itinerarios") or die(mysql_error());
?>