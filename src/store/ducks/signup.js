export const Types = {
  CALL_SIGNUP: 'signup/CALL_SIGNUP',
  SUCCESS_SIGNUP: 'signup/SUCCESS_SIGNUP',
  FAILURE_SIGNUP: 'signup/FAILURE_SIGNUP',
};

export const INITIAL_STATE = {
  loading: false,
  message: null,
};

export default function login(state = INITIAL_STATE, action) {
  switch (action.type) {
  case Types.CALL_SIGNUP:
    return {
      ...state,
      loading: true,
      error: null,
    };
  case Types.FAILURE_SIGNUP:
    return {
      ...state,
      loading: false,
      message: action.payload.error,
    };
  case Types.SUCCESS_SIGNUP:
    return {
      ...state,
      loading: false,
      message: 'Usuário cadastrado com sucesso',
    };
  default:
    return state;
  }
}

export const Creators = {
  callSignup: (email, name, username, password, phone, document) => ({
    type: Types.CALL_SIGNUP,
    payload: {
      name,
      username,
      password,
      email,
      document,
      phone,
    }
  }),
  failureSignup: error => ({
    type: Types.FAILURE_SIGNUP,
    payload: {
      error,
    },
  }),
  successSignup: data => ({
    type: Types.SUCCESS_SIGNUP,
  }),
}
