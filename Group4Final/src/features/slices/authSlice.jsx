import { createSlice } from "@reduxjs/toolkit";

export const authSlice = createSlice({
  name: "auth",
  initialState: {
    user: JSON.parse(sessionStorage.getItem("authUser")) || {
      name: "",
      password: "",
      image: "",
      authUser: false,
    },
  },
  reducers: {
    login(state, action) {
      const { name, password, image } = action.payload;

      // Tài khoản mặc định để đăng nhập
      const defaultName = "TestUser";
      const defaultPassword = "Pass1!";

      // Kiểm tra thông tin đăng nhập
      if (name === defaultName && password === defaultPassword) {
        state.user = { name, password, image, authUser: true };
        sessionStorage.setItem("authUser", JSON.stringify(state.user));
      } else {
        state.user = { name: "", password: "", image: "", authUser: false };
      }
    },
    logout(state) {
      state.user = {
        name: "",
        password: "",
        image: "",
        authUser: false,
      };
      sessionStorage.clear();
    },
  },
});

export const { login, logout } = authSlice.actions;
export default authSlice.reducer;
