
export class AxiosBase {
    public axios: any;

    constructor() {
        this.axios = require("axios");
    }

}

export class HomeService {
    static urlBase = "http://localhost:13161/api/";
    static AxiosBase = new AxiosBase();

    //HomeController/GetAllVideoGames()
    static async GetAllVideoGames(): Promise<VideoGameModel[]> {
        const url = this.urlBase + "Home/GetAllVideoGame";
        const response = await this.AxiosBase.axios.get(url);
        return response.data as VideoGameModel[];
    }

    static async GetVideoGameByGameType(gameTypeName : string): Promise<VideoGameModel[]> {
        const url = this.urlBase + "Home/GetVideoGameByGameType";
        const response = await this.AxiosBase.axios.get(url, {params: {gameTypeName: gameTypeName}});

        return response.data as VideoGameModel[];
    }
}

export class GameTypeService {
    static urlBase = "http://localhost:13161/api/";
    static AxiosBase = new AxiosBase();

    static async GetAll(): Promise<string[]> {
        const url = this.urlBase + "GameType/GetAll";
        const response = await this.AxiosBase.axios.get(url);
        return response.data as string[];
    }
}


export class AdminService {
    static urlBase = "http://localhost:13161/api/";
    static AxiosBase = new AxiosBase();

    static async AddVideoGame(data: FormAddVideoGameParams): Promise<boolean> {

        const addVideoGameForm = new FormAddVideoGameParams({

            GameName : data.GameName as string,
            StudioDeveloper : data.StudioDeveloper as string,
            GamePicture : data.GamePicture as string,
            GameType : data.GameType as string,
        });
        
        debugger;
        const url = this.urlBase + "Admin/AddVideoGame";
        const response = await this.AxiosBase.axios.post(url, addVideoGameForm);
        return response.data as boolean;
        
    }

    static async RemoveVideoGameById(Id: number | undefined): Promise<boolean> {     
        
        const url = this.urlBase + "Admin/RemoveVideoGameById";
        const response = await this.AxiosBase.axios.get(url, {params: {videoGameId: Id as number}});
        
        return response.data as boolean;
    }

    static async GetVideoGameById(id: number): Promise<VideoGameModel> {
        const url = this.urlBase + "Admin/GetVideoGameById";
        const response = await this.AxiosBase.axios.get(url, {params: { id: id}});
        return response.data as VideoGameModel;
    }

    static async EditVideoGame(data: FormAddVideoGameParams): Promise<boolean> {
        
        const editVideoGameForm = new FormAddVideoGameParams({

            Id: data.Id as number,
            GameName : data.GameName as string,
            StudioDeveloper : data.StudioDeveloper as string,
            GamePicture : data.GamePicture as string,
            GameType : data.GameType as string,
        });

        const url = this.urlBase + "Admin/EditVideoGame";
        const response = await this.AxiosBase.axios.post(url, editVideoGameForm);
        return response.data as boolean;
        
    }

    static async RemoveAllVideoGames(): Promise<boolean> {
        const url = this.urlBase + "Admin/RemoveAllVideoGames";
        const response = await this.AxiosBase.axios.get(url);
        return response.data as boolean;
    }
}


export class VideoGameModel {
    /** Id */
    'Id': number;

    'GameName'?: string;

    'StudioDeveloper'?: string;

    'GamePicture'?: string;

    'GameType'?: string;

    constructor(data: undefined | any = {}) {
        this['Id'] = data['Id'];
        this['GameName'] = data['GameName'];
        this['StudioDeveloper'] = data['TStudioDeveloperext'];
        this['GamePicture'] = data['GamePicture'];
        this['GameType'] = data['GameType'];       
    }
    public static validationModel = {};
}

export class FormAddVideoGameParams {

    'Id': number | undefined;

    'GameName'?: string;

    'StudioDeveloper'?: string;

    'GamePicture'?: string;

    'GameType'?: string;

    constructor(data: undefined | any = {}) {
        this['Id'] = data['Id'];
        this['GameName'] = data['GameName'];
        this['StudioDeveloper'] = data['StudioDeveloper'];
        this['GamePicture'] = data['GamePicture'];
        this['GameType'] = data['GameType'];       
    }
    public static validationModel = {};
}