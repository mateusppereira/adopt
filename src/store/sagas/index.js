import { takeLatest, all } from 'redux-saga/effects';
import { callSignup } from './signup'
import { callLogin } from './login'
import { Types as LoginTypes } from 'store/ducks/login'
import { Types as SignupTypes } from 'store/ducks/signup'

export default function* rootSaga() {
  yield all([
    takeLatest(LoginTypes.CALL_LOGIN, callLogin),
    takeLatest(SignupTypes.CALL_SIGNUP, callSignup),
  ])
}