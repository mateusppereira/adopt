import colors from './colors';
import metrics from './metrics';

export default {
  container: {
    flex: 1,
  },
  row: {
    flexDirection: 'row',
  },
  input: {
    paddingHorizontal: metrics.basePadding / 2,
    backgroundColor: colors.white,
    borderRadius: metrics.baseRadius,
    height: 44,
    width: '100%',
    marginVertical: metrics.baseMargin,
    elevation: 2,
  },
  box: {
    padding: metrics.basePadding,
    backgroundColor: colors.white,
  },
  separator :{
    height: 1,
    backgroundColor: colors.light,
  },
  buttonText: {
    fontSize: 16,
    color: colors.white,
  },
  btnFull: {
    backgroundColor: colors.secondary,
    borderRadius: metrics.baseRadius,
    height: 44,
    width: '100%',
    paddingVertical: metrics.basePadding,
    justifyContent: 'center',
    alignItems: 'center',
    elevation: 2,
  },
  itemInfo: {
    flexDirection: 'row',
    marginVertical: metrics.baseMargin / 2,
  },
  textKey: {
    fontWeight: 'bold',
    fontSize: 14,
    marginRight: metrics.baseMargin / 2,
  },
  textValue: {
    fontSize: 14,
    flex: 1,
  },
};
