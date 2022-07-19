import { createAsyncThunk } from "@reduxjs/toolkit";
import { FETCH_USER } from "../../../common/consts/actionTypes";
import { LoginUser } from "../../../common/models/user/LoginUser";
import { authSrv } from "../../services/authSrv";

export const loginAction = createAsyncThunk(
  FETCH_USER,
  async (cridentials: LoginUser) => {
    try {
      return await authSrv.login(cridentials);
    } catch (e: any) {
      return e.json();
    }
  }
);
