import { StyleSheet } from 'react-native';
import { colors, metrics, general } from 'styles';

const styles = StyleSheet.create({
  imagesSection: {
    flex: 4,
    backgroundColor: colors.regular,
  },
  photo: {
    width: '100%',
    height: '100%',
  },
  infoSection: {
    flex: 5,
    backgroundColor: colors.lighter,
    paddingHorizontal: metrics.basePadding,
    paddingVertical: metrics.basePadding / 2,
  },
  textHeader: {
    fontSize: 42,
    color: colors.black,
  },
  boxDescription: {
    width: "100%",
    maxHeight: 100,
    backgroundColor: colors.light,
    borderRadius: 10,
    padding: metrics.basePadding,
    marginVertical: metrics.baseMargin * 2,
  },
  textDescription: {
    fontSize: 18,
    color: colors.black,
  },
  textKey: {
    ...general.textKey,
    fontSize: 18,
  },
  textValue: {
    ...general.textValue,
    fontSize: 18,
  },
  btnAdopt: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: colors.primary,
  }
});

export default styles;
