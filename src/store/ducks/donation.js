export const Types = {
  GET: 'donation/GET',
  GET_FAILURE: 'donation/GET_FAILURE',
  GET_SUCCESS: 'donation/GET_SUCCESS',
  SET_CURRENT: 'donation/SET_CURRENT',
};

export const INITIAL_STATE = {
  list: [],
  current: {},
  loading: false,
  error: null,
};

export default function login(state = INITIAL_STATE, action) {
  switch (action.type) {
  case Types.SET_CURRENT:
    return {
      ...state,
      current: action.payload.item,
    };
  case Types.GET:
    return {
      ...state,
      loading: true,
      error: null,
    };
  case Types.GET_FAILURE:
    return {
      ...state,
      error: action.payload.error,
      loading: false,
    };
  case Types.GET_SUCCESS:
    return {
      ...state,
      loading: false,
      list: action.payload.list,
    };
  default:
    return state;
  }
}

export const Creators = {
  setCurrent: item => ({
    type: Types.SET_CURRENT,
    payload: {
      item,
    }
  }),
  get: () => ({
    type: Types.GET,
  }),
  getFailure: error => ({
    type: Types.GET_FAILURE,
    payload: {
      error,
    },
  }),
  getSuccess: list => ({
    type: Types.GET_SUCCESS,
    payload: {
      list,
    }
  }),
}
