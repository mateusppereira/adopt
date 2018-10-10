import React, { Component } from 'react';
import { View, Text } from 'react-native';
import { general } from 'styles';
import styles from './styles';

const imgDog = require('../../res/dog.png');
const imgCat = require('../../res/cat.png');

class Main extends Component {
  render() {
    return (
      <View style={general.container}>
        <View style={styles.section}>
          <View style={styles.sectionAnimals}>
            <View style={styles.sectionAnimal}>
              <Image src={imgDog} />
            </View>
            <View style={styles.sectionAnimal}>
              <Image src={imgCat} />
            </View>
          </View>
        </View>
        <View style={styles.section}>
        </View>
        <View style={styles.section}>
        </View>
      </View>
    );
  }
}

export default Main