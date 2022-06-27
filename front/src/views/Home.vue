<template>
  <div>
    <div class="content-title">
      <h1>Список игр</h1>
    </div>

    <div class="content-inp">
      <h2>Фильтр по жанру</h2>
      <div class="filtr-block">
        <select class="content-select" v-model="filtrData">
          <option selected>Все жанры</option>
          <option v-for="item in getGameType" v-bind:value="item">{{ item }} </option>
        </select>
        <v-btn @click="findByFiltr()">Поиск</v-btn>
      </div>

      <ul class="game-list">
        <li v-for="item in videoGame">
          <h1>{{ item.GameName }}</h1>
          <div class="divForImg"><img :src="item.GamePicture"></div>
          <p class="StudioDeveloper"> Студия разработчик: <span
              class="StudioDeveloperItem">{{ item.StudioDeveloper }}</span></p>
          <p class="GameType"><span class="Type">Жанр/ы: </span> <span class="buttonStyle">{{ item.GameType}}</span></p>
        </li>
      </ul>

    </div>
  </div>
</template>

<script lang="ts">
import { VideoGameModel, HomeService, GameTypeService } from '@/AxiosSetup/service';
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: {},
})

export default class Home extends Vue {
  public videoGame: VideoGameModel[] = [];      //Список игр
  public allGameType: string[] = [];            //Все жанры игр
  public filtrData: string = 'Все жанры';       //Фильтр

  async created() {
    try {
      this.videoGame = await HomeService.GetAllVideoGames();
    }
    catch (e) {
      alert("Ошибка получения игр");
    }

    try {
      this.allGameType = await GameTypeService.GetAll();
    }
    catch (e) {
      alert("Ошибка получения жанров");
    }


  }

  public async findByFiltr() {
    this.videoGame = await HomeService.GetVideoGameByGameType(this.filtrData);
  }

  get getVideoGame() {
    return this.videoGame;
  }

  get getGameType() {
    return this.allGameType;
  }

}

</script>

<style scoped>
h1 {
  margin-bottom: 0px;
}

button {
  width: 100px;
  height: 32px;
  margin-left: 10px;
}

.filtr-block {
  margin-top: 10px;
  margin-bottom: 30px;
}

.content-select {
  height: 35px;
  width: 250px;
  font-size: 20px;
  border: 1px solid silver;
  border-radius: 5px;
}

.game-list li {
  padding: 20px 0;
  min-height: 200px;
  border-top: 1px solid silver;
}

.game-list .StudioDeveloper {
  font-weight: bold;
  display: inline-block;
  margin-left: 10px;
  position: relative;
  top: -156px;
}

.game-list .GameType {
  position: relative;
  top: -156px;
  left:-8px;
}

.game-list .divForImg {
  width: 300px;
  height: 169px;
  display: inline-block;
}
.game-list .Type{
font-weight: bold;
}

.game-list .StudioDeveloperItem {
  font-weight: 100;
}

.game-list li h1 {
  margin-bottom: 10px;
}

.game-list li img {
  float: left;
  width: 300px;
  max-height: 400px;
  margin-right: 20px;
  margin-left: 0;
}

.game-list li p {
  margin-left: 320px;
  font-size: 18px;
}

.game-list .buttonStyle {
  border: 1px solid #808080 !important;
  color: black;
  background-color: white;
  padding: 5px 15px;
  cursor: pointer;
  margin-left: 5px;
}

.game-list .buttonStyle:hover {
  background-color: #808080;
  color: white;
  transition: 0.5s;
}
</style>
