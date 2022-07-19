import { api } from "../../common/axiosConnection";
import { LoginUser } from "../../common/models/user/LoginUser";
import { RegisterUser } from "../../common/models/user/RegisterUser";

const controllerPath = "account/";

export const authSrv = {
  async login(credential: LoginUser) {
    try {
      return await api
        .post(controllerPath + "login", credential)
        .then((r) => r.data);
    } catch (e) {
      console.error(e);
    }
  },

  async register(credential: RegisterUser) {
    try {
      return await api
        .post(controllerPath + "register", credential)
        .then((r) => r.data);
    } catch (e) {
      console.error(e);
    }
  },
};
