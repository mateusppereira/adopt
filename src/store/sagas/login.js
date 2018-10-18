import { call, put } from 'redux-saga/effects';
import { NavigationActions } from 'react-navigation';
import { Creators as LoginActions } from 'store/ducks/login';
import axios from 'axios';

export function* callLogin(action) {
  try {
    const { login, password, navigation } = action.payload;
    if (!login || !password) {
      yield put(LoginActions.failureLogin('Favor informar suas credenciais'));
    } else {
      // const response = yield call(axios.get, 'http://www.mocky.io/v2/5bb554833000006d00aabcf9');
      const response = {
        data: {
          hasErrors: false,
          message: "",
          objectResult: null,
        }
      }
      if (response.data.hasErrors) {
        yield put(LoginActions.failureLogin(response.data.message));      
      }
      if (navigation) {
        yield call(navigation.navigate, 'Main');
      }
      yield put(LoginActions.successLogin(response.data));
    }
  } catch (error) {
    console.tron.log(error + " sds");
    yield put(LoginActions.failureLogin());
  }
}
