import { StyleSheet } from 'react-native';
import { metrics, colors } from 'styles';

const styles = StyleSheet.create({
  section: {
    flex: 1,
    marginVertical: metrics.baseMargin ,
    marginHorizontal: metrics.baseMargin,
    backgroundColor: colors.lighter,
  },
  sectionAnimals: {
    flexDirection: 'row',
    borderRadius: metrics.baseRadius,
  },
  sectionDog: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    marginRight: metrics.baseMargin,
    padding: 5,
    borderRadius: metrics.baseRadius,
    backgroundColor: colors.primary,
  },
  sectionCat: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    marginLeft: metrics.baseMargin,
    borderRadius: metrics.baseRadius,
    backgroundColor: colors.primary,
  },
  sectionDogCat: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    padding: metrics.basePadding / 2,
    borderRadius: metrics.baseRadius,
    backgroundColor: colors.primary,
  },
  sectionChat: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    padding: metrics.basePadding / 2,
    borderRadius: metrics.baseRadius,
    backgroundColor: colors.primary,
  },
  thumbnail: {
    width: 150,
    height: 120,
  },
  thumbnailDogCat: {
    width: "70%",
    height: "90%",
  },
  thumbnailChat: {
    width: "35%",
    height: "75%",
  },
  textDesc: {
    fontSize: 16,
    alignSelf: 'center',
    color: colors.white,
  }
});

export default styles;
