<template>
  <div>
    <!--Хедер -->
    <div class="header">
      <router-link class="title" to="/Home/Game">GameDev.com</router-link>
    </div>

    <!--Left block -->
    <div class="left-block">
      <ul>
        <li>
          <router-link to="/"
            ><div>
              <img src="@/assets/Games.png" /><span>Список игр</span>
            </div></router-link
          >
        </li>
        <li>
          <router-link to="/Home/ReviewTask"
            ><img src="@/assets/Task.png" /><span>Задание</span></router-link
          >
        </li>
        <li>
          <router-link to="/Home/Tehknology"
            ><img src="@/assets/Tek.png" /><span>Технологии</span></router-link
          >
        </li>
        <li>
          <router-link to="/Admin/Game"
            ><img src="@/assets/Data.png" /><span>Админка</span></router-link
          >
        </li>
      </ul>
    </div>

    <!--Content block -->
    <div class="content">
      <router-view />
    </div>
  </div>
</template>

<style>
* {
  margin: 0;
  padding: 0;
}

body{
background-color: #fafafa;
}

a {
  list-style: none;
  text-decoration: none;
  color: black;
}

li{
  list-style: none;
}

.title {
  font-size: 24px;
  color: white;
  margin-top: 10px;
}

.header {
  position: fixed;
  z-index: 100000;
  width: 100%;
  height: 30px;
  padding: 10px 10px;
  background-color: #1c89e6;
}

.left-block {
  position: fixed;
  top: 50px;
  width: 220px;
  height: 100%;
  border-right: 1px solid #cccccc;
  background-color: white;
}

.left-block ul li {
  list-style: none;
  margin: 25px 0 15px 15px;
}

.left-block ul li:first-child {
  margin: 30px 0 15px 15px;
}

.left-block ul li span{
  margin-left: 35px;
}

.left-block ul li a{
  font-size: 20px;
  color: #333333;
}

.left-block ul li a img {
  position: absolute;
  width: 25px;
  height: 25px;
  margin-top: -2px;
}

.content {
  position: relative;
  top: 50px;
  margin-left: 220px;
  min-height: 600px;
  padding: 20px 40px;
}

.content-inp{
  padding: 20px;
  background-color: white;
  border: 1px solid #e0e0e0;
  margin-top: 15px;
  border-radius: 5px;
}

.content-title{
  padding: 20px;
  background-color: white;
  border: 1px solid #e0e0e0;
  border-radius: 5px;
}
</style>
