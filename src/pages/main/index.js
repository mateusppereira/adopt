import React, { Component } from 'react';
import { View, TouchableOpacity, Image } from 'react-native';
import { general } from 'styles';
import styles from './styles';

const imgDog = require('../../res/dog.png');
const imgCat = require('../../res/cat.png');
const imgDogCat = require('../../res/dogcat.png');

class Main extends Component {
  render() {
    return (
      <View style={general.container}>
        <View style={styles.section}>
          <View style={styles.sectionAnimals}>
            <TouchableOpacity style={styles.sectionDog}>
              <Image source={imgDog} style={styles.thumbnail} />
            </TouchableOpacity>
            <TouchableOpacity style={styles.sectionCat}>
              <Image source={imgCat} style={styles.thumbnail} />
            </TouchableOpacity>
          </View>
        </View>
        <View style={styles.section}>
          <TouchableOpacity style={styles.sectionCat}>
            <Image source={imgDogCat} style={styles.thumbnailDogCat} />
          </TouchableOpacity>
        </View>
        <View style={styles.section}>
        </View>
      </View>
    );
  }
}

export default Main