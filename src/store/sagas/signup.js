import { call, put } from 'redux-saga/effects';
import { Creators as SignupActions } from 'store/ducks/signup';
import axios from 'axios';

export function* callSignup(action) {
  try {
    const { name, username, password, email, document } = action.payload;
    // const response = yield call(axios.get, 'http://www.mocky.io/v2/5bb554833000006d00aabcf9', {
    //   name,
    //   username,
    //   password,
    //   email,
    //   document
    // });
    const response = {
      data: {
        hasErrors: false,
        message: "",
        objectResult: null,
      }
    }
    if (response.data.hasErrors) {
      yield put(SignupActions.failureSignup(response.data.message));      
    } else {
      yield put(SignupActions.successSignup());
    }
  } catch (error) {
    yield put(SignupActions.failureSignup());
  }
}
