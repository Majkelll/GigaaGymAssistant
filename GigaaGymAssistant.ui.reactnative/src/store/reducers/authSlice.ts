import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { User, UserInitialState } from "../../common/models/user/User";
import { loginAction } from "../actions/auth/loginAction";

export const authSlice = createSlice({
  name: "auth",
  initialState: UserInitialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(
      loginAction.fulfilled,
      (state: User, action: PayloadAction<User, string>) => {
        if (action.payload !== undefined) {
          state.id = action.payload.id;
          state.firstName = action.payload.firstName;
          state.lastName = action.payload.lastName;
          state.email = action.payload.email;
          state.token = action.payload.token;
        }
      }
    );
  },
});

export default authSlice.reducer;
