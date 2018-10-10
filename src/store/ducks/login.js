export const Types = {
  CALL_LOGIN: 'login/CALL_LOGIN',
  SUCCESS_LOGIN: 'login/SUCCESS_LOGIN',
  FAILURE_LOGIN: 'login/FAILURE_LOGIN',
};

export const INITIAL_STATE = {
  credentials: {
    login: null,
    password: null,
  },
  data: {},
  logged: false,
  loading: false,
  error: null,
};

export default function login(state = INITIAL_STATE, action) {
  console.tron.log(action);
  switch (action.type) {
  case Types.CALL_LOGIN:
    return {
      ...state,
      credentials: {
        login: action.payload.login,
        password: action.payload.password,
      },
      logged: false,
      loading: true,
      error: null,
    };
  case Types.FAILURE_LOGIN:
    return {
      ...state,
      credentials: {
        login: null,
        senha: null,
      },
      logged: false,
      error: action.payload.error,
      loading: false,
    };
  case Types.SUCCESS_LOGIN:
    return {
      ...state,
      data: action.payload.data,
      logged: true,
      loading: false,
      error: null,
    };
  default:
    return state;
  }
}

export const Creators = {
  callLogin: (login, password, navigation) => ({
    type: Types.CALL_LOGIN,
    payload: {
      login,
      password,
      navigation,
    }
  }),
  failureLogin: error => ({
    type: Types.FAILURE_LOGIN,
    payload: {
      error,
    },
  }),
  successLogin: data => ({
    type: Types.SUCCESS_LOGIN,
    payload: {
      data,
    }
  }),
}
