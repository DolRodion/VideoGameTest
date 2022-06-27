<template>
  <div>
    <div class="content-title">
      <h1>Зона администратора</h1>
    </div>

    <div class="content-inp">
      <router-link class="work-button" to="/Admin/addVideoGame">Добавить</router-link>
      <a class="work-button" v-on:click="removeAllVideoGames()" to="/Admin/Game">Удалить всe игры</a>
    </div>

    <div class="content-inp">

      <table class="table-data">
        <thead>
          <tr>
            <th>Id</th>
            <th>Название</th>
            <th>Студия разработчик</th>
            <th>Жанр/ы</th>
            <th>Картинка</th>
            <th>Управление</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in getData">
            <td>{{ item.Id }}</td>
            <td>{{ item.GameName }}</td>
            <td>{{ item.StudioDeveloper }}</td>
            <td><p> {{item.GameType}}</p></td>
            <td><img :src="item.GamePicture"></td>
            <td>
              <a v-on:click="GetId(item.Id)" to="/Admin/Game">Удалить</a> / <router-link to="/Admin/editVideoGame" :to="getVideoGameId(item.Id)">Редактировать</router-link>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script lang="ts">
import { VideoGameModel, AdminService, HomeService } from '@/AxiosSetup/service';
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: {},
})
export default class AdminPage extends Vue { 
  private data: VideoGameModel[] = [];
 

  async created() {

    this.data = await HomeService.GetAllVideoGames();
  }

   public getVideoGameId(id: any) {
    return "/admin/editVideoGame/" + id;
  }

  public async removeAllVideoGames()
  {
    try{
      const deleteAll = await AdminService.RemoveAllVideoGames();

      if (deleteAll){
        alert("Игры успешно удалены");
        location.reload();
      }
    }
    catch(e)
    {
      alert("Неизвестная ошибка");
    }
  }

  public async GetId(Id: number) {
    try{
      const result = await AdminService.RemoveVideoGameById(Id);

      if (result){
        alert("Запись успешно удалена");
        location.reload();
      }
    }
    catch(e)
    {
      alert("Идентификатор не найден");
    }
  }
  
  get getData() {
    return this.data;
  }
}
</script>

<style scoped>
a {
  cursor: pointer;
  color: #1c89e6;
}

h1{
  margin-bottom: 0px;
}

.table-data {
  width: 100%;
  margin-bottom: 20px;
  border: 1px solid #dddddd;
  border-collapse: collapse;
  font-size: 22px;
  margin-top: 25px;
}

.table-data tr {
  padding: 5px 0;
}

.table-data th {
  font-weight: bold;
  padding: 15px;
  background: #efefef;
  border: 1px solid #dddddd;
  text-align: center;
  width: 20px;
}

.table-data th img{
  height: 100px;
}

.table-data td {
  border: 1px solid #dddddd;
  padding: 15px;
  text-align: center;
}

.table-data img {
  width: 200px;
  height: 100px;
}

.filtr-block {
  margin-top: 10px;
  margin-bottom: 30px;
}

.content-select {
  height: 40px;
  width: 250px;
  font-size: 20px;
  border: 1px solid silver;
  border-radius: 5px;
}

.content-find{
  width: 200px;
  height: 42px;
  margin-left: 30px;
  float: right;
  background-color: white;
  border-radius: 5px;
  border: 1px solid green;
  font-size: 18px;
  cursor: pointer;
}

.work-button{
  padding: 10px 40px;
  background-color: white;
  margin-left: 20px;
  border: 1px solid green;
  border-radius: 5px;
  font-size: 18px;
  cursor: pointer;
}
</style>
