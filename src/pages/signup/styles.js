import { StyleSheet } from 'react-native';
import { general, colors, metrics } from 'styles';

const styles = StyleSheet.create({
  header: {
    height: 150,
    alignItems: 'center',
    backgroundColor: colors.white,
  },
  body: {
    flex: 1,
    paddingHorizontal: metrics.basePadding,
  },
  form: {
    height: '80%',
  },
  footer: {
    height: '20%',
  },
  btnSignup: {
    ...general.btnFull,
    marginTop: metrics.basePadding * 1.5,
    backgroundColor: colors.secondary,
  },
  textSignup: {
    color: colors.white,
  },
  textError: {
    marginTop: metrics.baseMargin,
    color: colors.danger,
  },
});

export default styles;
